from django.core.management.base import BaseCommand
from shopapp.models import Order, Client, Product
from random import choice, choices, randint


class Command(BaseCommand):
    help = "Creates fake order in the database"

    def add_arguments(self, parser):
        parser.add_argument('quantity', type=int, help='Quantity of orders')

    def handle(self, *args, **kwargs):
        quantity = kwargs['quantity']
        clients = Client.objects.all()
        products = Product.objects.all()
        for i in range(quantity):
            order = Order(client=choice(clients))
            order.save()
            order.products.add(*choices(products, k=randint(1, 10)))
            order.set_overall_price()
            order.save()
        self.stdout.write(f'done')
