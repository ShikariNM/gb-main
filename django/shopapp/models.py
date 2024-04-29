from django.db import models
from django.utils import timezone


class Client(models.Model):
    name = models.CharField(max_length=128)
    email = models.EmailField()
    phone_number = models.CharField(max_length=32)
    address = models.CharField(max_length=64)
    registration_date = models.DateField(default=timezone.now)

    def __str__(self):
        return f'{self.pk} - {self.name}'


class Product(models.Model):
    title = models.CharField(max_length=32)
    description = models.TextField()
    price = models.DecimalField(max_digits=8, decimal_places=2)
    stock = models.IntegerField(default=1)
    supplement_date = models.DateField(default=timezone.now)
    image = models.ImageField(upload_to='product_images', null=True)

    def __str__(self):
        return f'{self.pk} - {self.title}'


class Order(models.Model):
    client = models.ForeignKey(Client, on_delete=models.SET('Unknown'))
    products = models.ManyToManyField(Product)
    overall_price = models.DecimalField(max_digits=8, decimal_places=2, default=0)
    placing_date = models.DateField(default=timezone.now)

    def set_overall_price(self):
        self.overall_price = sum(product.price for product in self.products.all())

    def __str__(self):
        return f'{self.pk} - {self.client}\n{self.products}'
