"""
Fetches stock data from trading view api
"""
import requests
import os
from dotenv import load_dotenv
from lib.payloads import stocsPayload_dict

def FetchData ():

    load_dotenv()
    url = os.getenv("BASE_URL")
    
    res = requests.post(url, json=stocsPayload_dict)
    data = res.json()

    clean_data = []

    for stock in data["data"]:
        clean_data.append({
            "symbol": stock["d"][0],
            "price": stock["d"][1],
        })

    return clean_data