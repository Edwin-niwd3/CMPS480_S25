from flask import Blueprint, render_template, request
from flask_login import login_required, current_user
from .models import StoredPassword
from .utils import decrypt_password, encrypt_password
from werkzeug.security import generate_password_hash
from . import db
from .models import StoredPassword

main = Blueprint('main', __name__)

@main.route('/')
def index():
    return render_template("index.html")

@main.route('/dashboard', methods=['GET', 'POST'])
@login_required
def dashboard():
    stored = StoredPassword.query.filter_by(user_id=current_user.id).all()
    passwords = [
        {"label": p.label, "password": decrypt_password(p.encrypted_password)}
        for p in stored
    ]
    if request.method == 'POST':
        label = request.form['label']
        password = request.form['password']
        if label == None or password == None:
            return render_template("dashboard.html", passwords=passwords)
        hashed = encrypt_password(password)
        new_password = StoredPassword(user_id = current_user.id, label = label, encrypted_password = hashed)
        db.session.add(new_password)
        db.session.commit()
        return render_template("dashboard.html", passwords=passwords)
    return render_template("dashboard.html", passwords=passwords)