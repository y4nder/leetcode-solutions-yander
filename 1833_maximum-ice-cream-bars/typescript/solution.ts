function maxIceCream(costs: number[], coins: number): number {
  const max = Math.max(...costs);
  const freq: number[] = Array(max + 1).fill(0);
  costs.forEach(cost => {
    freq[cost] += 1;
  });

  let count = 0;
  let remaining = coins;

  for (let price = 0; price <= max; price++) {
    if (remaining < price) break;
    const can_buy = Math.min(freq[price], Math.floor(remaining / price));
    count += can_buy;
    remaining -= can_buy * price;
  }

  return count;
};
