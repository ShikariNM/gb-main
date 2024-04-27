from django.core.management.base import BaseCommand
from shopapp.models import Product
from datetime import date
from decimal import Decimal


class Command(BaseCommand):
    help = "Changes a product in the database by id "

    def add_arguments(self, parser):
        parser.add_argument('pk', type=int, help='Product ID')
        parser.add_argument('field', type=str, help="Field you'd like to change")
        parser.add_argument('value', type=str, help="A new value of the field")

    def handle(self, *args, **kwargs):
        pk = kwargs['pk']
        field = kwargs['field']
        value = kwargs['value']
        product = Product.objects.filter(pk=pk).first()
        match field:
            case 'price':
                value = Decimal(value)
            case 'stock':
                value = int(value)
            case 'supplement_date':
                value = date.fromisoformat(value)
        setattr(product, field, value)
        product.save()
        self.stdout.write(f'The product has been changed.\n'
                          f'new value of {field} is {value}')
