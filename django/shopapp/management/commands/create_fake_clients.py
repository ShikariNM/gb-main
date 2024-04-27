from django.core.management.base import BaseCommand
from shopapp.models import Client


class Command(BaseCommand):
    help = "Creates fake clients in the database"

    def add_arguments(self, parser):
        parser.add_argument('quantity', type=int, help='Quantity of clients')

    def handle(self, *args, **kwargs):
        quantity = kwargs['quantity']
        for i in range(quantity):
            client = Client(
                name=f'name{i}',
                email=f'mail{i}@mail.com',
                phone_number=f'NUMBERS{i}',
                address=f'address{i}'
            )
            client.save()
        self.stdout.write(f'done')
