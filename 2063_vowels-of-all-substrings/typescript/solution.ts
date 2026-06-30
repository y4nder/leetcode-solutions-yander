function countVowels(word: string): number {
  const n = word.length;

  let total = 0;

  function exists(c: string) {
    switch (c) {
      case 'a':
      case 'e':
      case 'i':
      case 'o':
      case 'u':
        return true;
      default:
        return false;
    }
  }

  for (let i = 0; i < n; i++) {
    if (exists(word[i])) {
      total += (i + 1) * (n - i);
    }
  }

  return total;
};
