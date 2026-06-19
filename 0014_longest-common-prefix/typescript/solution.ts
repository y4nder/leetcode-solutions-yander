function longestCommonPrefix(strs: string[]): string {
  if (strs.length === 0) return "";

  const reference = strs[0];

  for (let i = 0; i < reference.length; i++) {
    let c = reference[i];
    for (let j = 1; j < strs.length; j++) {
      if (i >= strs[j].length || strs[j][i] !== c)
        return reference.substring(0, i);
    }

  }
  return reference;
};
