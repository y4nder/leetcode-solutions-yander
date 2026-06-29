const fs = require("fs");
const path = require("path");

// Load the bare LeetCode function from solution.ts without requiring it to
// export anything, so solution.ts stays exactly as submitted. TypeScript type
// annotations are invalid JS, so the source is transpiled before eval.
function loadSolution() {
  const src = fs.readFileSync(path.join(__dirname, "solution.ts"), "utf8");
  const js = new Bun.Transpiler({ loader: "ts" }).transformSync(src);
  return new Function(js + "\nreturn searchInsert;")();
}

function main() {
  const data = fs.readFileSync(0, "utf8").split(/\r?\n/);
  const nums = JSON.parse(data[0]); // integer[]
  const target = JSON.parse(data[1]); // integer
  const result = loadSolution()(nums, target);
  console.log(JSON.stringify(result ?? null));
}

main();
