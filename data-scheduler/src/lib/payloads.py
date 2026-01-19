from dataclasses import asdict
from lib.payload_classes import Filter
from lib.payload_classes import Sort
from lib.payload_classes import Payload

stocksPayload = Payload(
    filters = [
        Filter("exchange", "in_range", ["NYSE", "NASDAQ"]),
        Filter("active_symbol", "equal", True),
    ],
    options={"lang": "en"},
    markets=["stocks"],
    symbols={"query": {"types": []}, "tickers": []},
    columns=["name", "close", "change", "change_abs", "volume"],
    sort=Sort(sortBy="close", sortOrder="desc"),
    range=[]
)

stocsPayload_dict = asdict(stocksPayload)