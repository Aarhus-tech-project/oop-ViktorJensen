from utils.fetch_stock_data import FetchData
from lib.mongo import insert_stock_data

def main():
    data = FetchData()
    print(data)
    insert_stock_data(data)


if __name__ == "__main__":
    main()
