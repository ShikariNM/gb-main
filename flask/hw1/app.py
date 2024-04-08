from flask import Flask, render_template, request

app = Flask(__name__)


@app.route('/')
def main():
    context = {
        'title': 'Main page',
        'content': 'Main page content',
    }
    return render_template('index.html', **context)


@app.route('/clothes/')
def get_clothes():
    context = {
        'title': 'Clothes',
        'content': [
            'jacket',
            'shirt',
            'jeans',
            'pants'
        ]
    }
    return render_template('clothes.html', **context)


@app.route('/shoes/')
def get_shoes():
    context = {
        'title': 'Shoes',
        'content': [
            'boots',
            'slippers',
            'sneakers',
        ]
    }
    return render_template('shoes.html', **context)


@app.route('/shoes/<item>/')
@app.route('/clothes/<item>')
def get_item(item):
    context = {
        'title': item,
        'content': {
            'description': f'{item} description',
            'photo_path': f'{item} photo path',
            'price': f'{item} price',
            'category': request.path.split('/')[1]
        }
    }
    return render_template('item.html', **context)
