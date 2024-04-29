from django.urls import path
from .views import (Clients, SpecificClient,
                    ProductsForDays, AddProductImage)

urlpatterns = [
    path('clients/', Clients.as_view(), name='clients'),
    path('clients/<int:client_id>/', SpecificClient.as_view(), name='specific_client'),
    path('products/<int:client_id>/<int:days>/', ProductsForDays.as_view(), name='products_for_days'),
    path('products/<int:product_id>/add_product_image/', AddProductImage.as_view(), name='add_product_image')
]
