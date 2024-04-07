from rectangle import Rectangle
import argparse

parser = argparse.ArgumentParser(description='Calculates rectangle perimeter or area')
parser.add_argument('width', metavar='w', type=float, help='enter the width of the rectangle')
parser.add_argument('length', metavar='l', type=float, help='enter the length of the rectangle')
parser.add_argument('-parameter', metavar='p', type=str,
                    help='enter "a" if you would like to calculate area, otherwise do not enter anithing',
                    default='p')
args = parser.parse_args()

r = Rectangle(args.width, args.length)
print(r.area() if args.parameter == 'a' else r.perimeter())

