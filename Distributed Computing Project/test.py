if __name__ == "__main__":
  from cryptography.fernet import Fernet
  print(Fernet.generate_key().decode())