from django.shortcuts import render, get_object_or_404
from django.views import View

from datetime import date, timedelta

from .models import Client, Order, Product
from .forms import ImageForm


class Clients(View):
    def get(self, request):
        context = {'clients': Client.objects.all()}
        return render(request, 'shopapp/clients.html', context)


class SpecificClient(View):
    def get(self, request, client_id):
        client = get_object_or_404(Client, pk=client_id)
        context = {'client': client}
        return render(request, 'shopapp/specific_client.html', context)


class ProductsForDays(View):
    def get(self, request, client_id, days):
        client = get_object_or_404(Client, pk=client_id)
        target_date = date.today() - timedelta(days=days)
        orders = Order.objects.filter(client=client, placing_date__gt=target_date).order_by('placing_date')
        print(len(orders))
        products = set()
        for order in orders:
            products.update(order.products.all())
        context = {
            'client': client,
            'days': days,
            'products': products,
        }
        return render(request, 'shopapp/products_for_days.html', context)


class AddProductImage(View):
    def get(self, request, product_id):
        form = ImageForm()
        message = 'Upload image:'
        return render(request, 'shopapp/add_product_image.html', {'form': form,
                                                                  'message': message})

    def post(self, request, product_id):
        product = get_object_or_404(Product, pk=product_id)
        form = ImageForm(request.POST, request.FILES)
        if form.is_valid():
            image = form.cleaned_data['image']
            product.image = image
            product.save()
            message = 'The image has been added'
        else:
            message = 'Form is not valid'
        return render(request, 'shopapp/add_product_image.html', {'form': form,
                                                                  'message': message})
