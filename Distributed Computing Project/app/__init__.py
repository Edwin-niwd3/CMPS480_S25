from flask import Flask
from flask_login import LoginManager
from flask_sqlalchemy import SQLAlchemy
from dotenv import load_dotenv
from os import getenv, path, makedirs

load_dotenv()

login_manager = LoginManager()

db = SQLAlchemy()

DB_NAME = "cloudstorage.db"
DB_FOLDER = "app"

def create_app():
  app = Flask(__name__)
  app.config['SECRET_KEY'] = getenv("SECRET_KEY")
  db_path = path.join(DB_FOLDER, DB_NAME)
  app.config['SQLALCHEMY_DATABASE_URI'] = f'sqlite:///{DB_NAME}'
  app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

  db.init_app(app)
  login_manager.init_app(app)
  login_manager.login_view = "auth.login"


  from .models import load_user, User, StoredPassword
  login_manager.user_loader(load_user)

  from .routes import main
  from .auth import auth

  
  app.register_blueprint(main)
  app.register_blueprint(auth)

  create_database(app, db_path)

  return app

def create_database(app, db_path):
  if not path.exists(DB_FOLDER):
    makedirs(DB_FOLDER)
    print('Made Folder!')
  if not path.exists(db_path):
    print(db_path)
    with app.app_context():
      db.create_all()
    print('Created Database!')