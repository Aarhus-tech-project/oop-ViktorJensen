"""
Fetches stock data from trading view api
"""
import requests

def FetchData ():

    url = "https://scanner.tradingview.com/america/scan"

    payload = {
        "filter": [
            {"left": "exchange", "operation": "in_range", "right": ["NYSE", "NASDAQ"]},
            {"left": "active_symbol", "operation": "equal", "right": True}
        ],
        "options": {"lang": "en"},
        "markets": ["stocks"],
        "symbols": {"query": {"types": []}, "tickers": []},
        "columns": [
            "name",
            "close",
            "change",
            "change_abs",
            "volume"
        ],
        "sort": {"sortBy": "volume", "sortOrder": "desc"},
        "range": [0, 50]        # Top 50 stocks sorted by volume
    }
    
    response = requests.post(url, json=payload)
    return response.json()