from django.core.management.base import BaseCommand
from shopapp.models import Product
from decimal import Decimal
from datetime import date


class Command(BaseCommand):
    help = "Creates a product in the database"

    def add_arguments(self, parser):
        parser.add_argument('title', type=str, help='Product title')
        parser.add_argument('description', type=str, help='Product description')
        parser.add_argument('price', type=str, help='Product price')
        parser.add_argument('stock', type=str, help='Product stock')
        parser.add_argument('supplement_date', type=str, help='Product supplement date')

    def handle(self, *args, **kwargs):
        product = Product(
            title=kwargs['title'],
            description=kwargs['description'],
            price=Decimal(kwargs['price']),
            stock=kwargs['stock'],
            supplement_date=date.fromisoformat(kwargs['supplement_date'])
        )
        product.save()
        self.stdout.write(f'done')
