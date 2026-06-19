function largestAltitude(gain: number[]): number {
  let max = 0;
  let altitude = 0;

  gain.forEach(g => {
    altitude += g;
    if (max < altitude) max = altitude;
  });

  return max;
};
