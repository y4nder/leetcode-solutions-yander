function numOfStrings(patterns: string[], word: string): number {
  let count = 0;

  patterns.forEach(pattern => {
    if (word.includes(pattern)) count++;
  });

  return count;
};
