from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, DateField, BooleanField
from wtforms.validators import DataRequired, Email, Length, EqualTo, ValidationError
import re


class RegisterForm(FlaskForm):
    first_name = StringField('First name', validators=[DataRequired()])
    last_name = StringField('Last name', validators=[DataRequired()])
    email = StringField('Email', validators=[DataRequired(), Email()])
    password = PasswordField('Password', validators=[DataRequired(), Length(min=8)])
    confirm_password = PasswordField('Confirm password', validators=[DataRequired(),
                                                                     EqualTo('password')])
    date_of_birth = DateField('Date of birth', validators=[DataRequired()])
    consent = BooleanField('Personal data processing consent', validators=[DataRequired()])


    def validate_password(self, field):
        if not re.search(r'\d', field.data) or not re.search(r'[a-zA-Z]', field.data):
            raise ValidationError('Password must contain at least one letter and one digit.')
