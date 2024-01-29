def binary_search(lst: list, value: object) -> int | Exception:
    if len(lst) == 0:
        raise ValueError(f"{value} is not in list")
    res = 0
    while len(lst) > 1:
        mid_idx = len(lst) // 2
        lst, res = (lst[:mid_idx], res) if lst[mid_idx] > value else (lst[mid_idx:], res+mid_idx)
    if lst[0] == value:
        return res
    else:
        raise ValueError(f"{value} is not in list")
