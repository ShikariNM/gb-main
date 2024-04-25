import sqlalchemy as sa
from sqlalchemy import create_engine
import databases

from settings import settings

DATABASE_URL = settings.DATABASE_URL
database = databases.Database(DATABASE_URL)
metadata = sa.MetaData()

users = sa.Table("users", metadata,
                 sa.Column("id", sa.Integer, primary_key=True),
                 sa.Column("first_name", sa.String(32)),
                 sa.Column("last_name", sa.String(32)),
                 sa.Column("email", sa.String(128)),
                 sa.Column("password", sa.String(64)))

products = sa.Table("products", metadata,
                    sa.Column("id", sa.Integer, primary_key=True),
                    sa.Column("title", sa.String(32)),
                    sa.Column("description", sa.String(256)),
                    sa.Column("price", sa.Float))

orders = sa.Table("orders", metadata,
                  sa.Column("id", sa.Integer, primary_key=True),
                  sa.Column("user_id", sa.Integer, sa.ForeignKey("users.id")),
                  sa.Column("product_id", sa.Integer, sa.ForeignKey("products.id")),
                  sa.Column("order_date", sa.Date),
                  sa.Column("is_done", sa.Boolean))

engine = create_engine(
    DATABASE_URL, connect_args={'check_same_thread': False}
)

metadata.create_all(engine)
