from dataclasses import dataclass

@dataclass
class Filter:
    left: str
    operation: str
    right: any


@dataclass
class Sort:
    sortBy: str
    sortOrder: str


@dataclass
class Payload:
    filters: list[Filter]
    options: dict[str, str]
    markets: list[str]
    symbols: dict[str, any]
    columns: list[str]
    sort: Sort
    range: list[int]