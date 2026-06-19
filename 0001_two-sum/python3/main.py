import sys
import json

from solution import Solution


def main():
    data = sys.stdin.read().splitlines()
    nums = json.loads(data[0])  # integer[]
    target = json.loads(data[1])  # integer
    result = Solution().twoSum(nums, target)
    print(json.dumps(result))


if __name__ == "__main__":
    main()
