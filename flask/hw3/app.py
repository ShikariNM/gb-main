from flask import Flask, render_template, request, flash
from flask_wtf.csrf import CSRFProtect
from secrets import token_hex
from hashlib import sha256

from hw3.models import db, User
from hw3.forms import RegisterForm


app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///users.db'
db.init_app(app)
app.config['SECRET_KEY'] = token_hex()
csrf = CSRFProtect(app)


@app.route('/')
def index():
    return render_template('index.html', title='Main page')


@app.cli.command("init-db")
def init_db():
    db.create_all()
    print('OK')


@app.route('/register/', methods=['GET', 'POST'])
def register():
    form = RegisterForm()
    context = {
        'title': 'Registration',
        'form': form
    }
    if request.method == 'POST':
        if form.validate():
            first_name = form.first_name.data
            last_name = form.last_name.data
            email = form.email.data
            if User.query.filter_by(first_name=first_name, last_name=last_name).first():
                flash(f'The user with the name like this already exists', 'danger')
            elif User.query.filter_by(email=email).first():
                flash(f'The user with the email like this already exists', 'danger')
            else:
                hashed_password = sha256(form.password.data.encode()).hexdigest()
                new_user = User(first_name=first_name,
                                last_name=last_name,
                                email=email,
                                password=hashed_password,
                                date_of_birth=form.date_of_birth.data,
                                consent=form.consent.data)
                db.session.add(new_user)
                db.session.commit()
                flash(f'You have registrated successfully', 'success')
    return render_template('register.html', **context)
