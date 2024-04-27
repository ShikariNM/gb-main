from django.core.management.base import BaseCommand
from shopapp.models import Order, Client, Product


class Command(BaseCommand):
    help = "Creates an order in the database"

    def add_arguments(self, parser):
        parser.add_argument('client', type=int, help='Order client')
        parser.add_argument('products', nargs='*', type=int, help='Order description')

    def handle(self, *args, **kwargs):
        order = Order(
            client=Client.objects.filter(pk=kwargs['client']).first(),
        )
        order.save()
        products = map(lambda x: Product.objects.filter(pk=int(x)).first(), kwargs['products'])
        for product in products:
            order.products.add(product)
        order.set_overall_price()
        order.save()
        self.stdout.write(f'done')
