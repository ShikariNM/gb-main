from django.core.management.base import BaseCommand
from shopapp.models import Order, Client, Product


class Command(BaseCommand):
    help = "Changes an order in the database by id "

    def add_arguments(self, parser):
        parser.add_argument('pk', type=int, help='Order ID')
        parser.add_argument('field', type=str, help="Field you'd like to change")
        parser.add_argument('value', nargs='*', type=str, help="A new value of the field")

    def handle(self, *args, **kwargs):
        pk = kwargs['pk']
        field = kwargs['field']
        value = kwargs['value']
        order = Order.objects.filter(pk=pk).first()
        match field:
            case 'client':
                value = Client.objects.filter(pk=int(value)).first()
                setattr(order, field, value)
                order.save()
            case 'products':
                products = map(lambda x: Product.objects.filter(pk=x).first(), value)
                for product in products:
                    order.products.add(product)
                order.set_overall_price()
                order.save()
        self.stdout.write(f'The order has been changed.\n'
                          f'new value of {field} is {value}')
