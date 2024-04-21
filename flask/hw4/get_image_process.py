from multiprocessing import Process

import sys

from time_decorators import time_decorator
from get_image_thread import download


@time_decorator()
def main(urls):
    processes = list()
    for url in urls:
        process = Process(target=download, args=[url])
        processes.append(process)
        process.start()

    for process in processes:
        process.join()


if __name__ == '__main__':
    main(sys.argv[1:])
