import os
import pprint

from pymongo.mongo_client import MongoClient
from pymongo.server_api import ServerApi
from dotenv import load_dotenv, find_dotenv
from datetime import datetime
def insert_stock_data(stock_data):
    """
    Docstring for insert_stock_data
    
    :param stock_data: Description
    """
    load_dotenv(find_dotenv())

    password = os.environ.get("DB_PWD")

    uri = f"mongodb+srv://viktor_adm:{password}@stock-db.xmvvmrp.mongodb.net/?appName=stock-db&tlsInsecure=true"

    try:
        client = MongoClient(uri, server_api=ServerApi('1'))
        db = client.api_data
        collection = db.stock_data

        for stock in stock_data:
            stock["timestamp"] = datetime.now()
        
        result = collection.insert_many(stock_data)
        print(f"Inserted {len(result.inserted_ids)} documents")
        print("About to insert:", (stock_data))
        return result
    except Exception as e:
        print(f"Error inserting data: {e}")
    finally:
        client.close()