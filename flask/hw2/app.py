from flask import Flask, render_template, request,\
    flash, redirect, url_for, make_response
from markupsafe import escape
import secrets

app = Flask(__name__)
app.secret_key = secrets.token_hex()


@app.route('/', methods=['GET', 'POST'])
@app.route('/authorize/', methods=['GET', 'POST'])
def authorize():
    if request.method == 'POST':
        name = request.form.get('name')
        email = request.form.get('email')
        if name and email:
            response = make_response(redirect(url_for('log_out', name=name)))
            response.set_cookie('name', name)
            response.set_cookie('email', email)
            return response
        else:
            flash('Enter valid values', 'danger')
        return redirect(url_for('authorize'))
    return render_template('authorize.html', title='Log in page')


@app.route('/log_out/<name>/', methods=['GET', 'POST'])
def log_out(name):
    if request.method == 'POST':
        response = make_response(redirect(url_for('authorize')))
        response.set_cookie('email', '', expires=0)
        response.set_cookie('name', '', expires=0)
        return response
    return render_template('log_out.html', title='Log out page', name=name)

