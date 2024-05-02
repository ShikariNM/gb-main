from django.contrib import admin
from django.utils.translation import gettext_lazy as _
from .models import Client, Product, Order

from datetime import date


class ClientAdmin(admin.ModelAdmin):
    list_display = ['pk', 'name']
    list_filter = ['registration_date']
    search_fields = ['name']
    search_help_text = 'Search by "name" field'

    readonly_fields = ['name', 'email', 'phone_number', 'address', 'registration_date']


class ProductAdmin(admin.ModelAdmin):
    @admin.action(description="Reset quantity to zero")
    def reset_stock(self, request, queryset):
        queryset.update(stock=0)

    @admin.action(description="Set supplement date to today")
    def set_supplement_date(self, request, queryset):
        queryset.update(supplement_date=date.today())

    class PriceRangeFilter(admin.SimpleListFilter):
        title = _('Price Range')
        parameter_name = 'price'

        def lookups(self, request, model_admin):
            return (
                ('0-20', _('0 - 20')),
                ('20-50', _('20 - 50')),
                ('50-', _('50 and above')),
            )

        def queryset(self, request, queryset):
            if self.value():
                start_price, end_price = map(int, self.value().split('-'))
                return queryset.filter(price__gte=start_price, price__lte=end_price)

    list_display = ['pk', 'title', 'price', 'stock']
    list_filter = ['supplement_date', PriceRangeFilter]
    search_fields = ['title']
    search_help_text = 'Search by "title" field'
    actions = [reset_stock, set_supplement_date]

    readonly_fields = ['supplement_date']
    fieldsets = [
        (
            None,
            {
                'classes': ['wide'],
                'fields': ['title'],
            },
        ),
        (
            'details',
            {
                'description': 'Thorough description',
                'fields': ['image', 'description'],
            },
        ),
        (
            'Accounting',
            {
                'classes': ['collapse'],
                'fields': ['price', 'stock'],
            }
        ),
        (
            'Other',
            {
                'fields': ['supplement_date'],
            }
        ),
    ]


class OrderAdmin(admin.ModelAdmin):
    list_display = ['client', 'overall_price']
    list_filter = ['client']
    search_fields = ['client']
    search_help_text = 'Search by "client" field'

    readonly_fields = ['placing_date']


admin.site.register(Client, ClientAdmin)
admin.site.register(Product, ProductAdmin)
admin.site.register(Order, OrderAdmin)
