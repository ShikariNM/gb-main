from django.core.management.base import BaseCommand
from shopapp.models import Client


class Command(BaseCommand):
    help = "Changes a client in the database by id "

    def add_arguments(self, parser):
        parser.add_argument('pk', type=int, help='Client ID')
        parser.add_argument('field', type=str, help="Field you'd like to change")
        parser.add_argument('value', type=str, help="A new value of the field")

    def handle(self, *args, **kwargs):
        pk = kwargs['pk']
        field = kwargs['field']
        value = kwargs['value']
        client = Client.objects.filter(pk=pk).first()
        setattr(client, field, value)
        client.save()
        self.stdout.write(f'The client has been changed.\n'
                          f'new value of {field} is {value}')
