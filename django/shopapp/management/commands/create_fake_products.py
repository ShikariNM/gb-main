from django.core.management.base import BaseCommand
from shopapp.models import Product
from random import randint
from decimal import Decimal


class Command(BaseCommand):
    help = "Creates fake products in the database"

    def add_arguments(self, parser):
        parser.add_argument('quantity', type=int, help='Quantity of products')

    def handle(self, *args, **kwargs):
        quantity = kwargs['quantity']
        for i in range(quantity):
            product = Product(
                title=f'title{i}',
                description=f'description{i}',
                price=Decimal(randint(10, 10000))/100,
                stock=randint(1, 50)
            )
            product.save()
        self.stdout.write(f'done')
