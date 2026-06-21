# Greedy Algorithm

<!--toc:start-->
- [Greedy Algorithm](#greedy-algorithm)
  - [The Basic Idea](#the-basic-idea)
  - [Beginner Explanation](#beginner-explanation)
  - [How to Recognize a Greedy Problem](#how-to-recognize-a-greedy-problem)
  - [The Two Properties That Make Greedy Safe](#the-two-properties-that-make-greedy-safe)
  - [High-Level Pseudocode (Generic Greedy)](#high-level-pseudocode-generic-greedy)
  - [Common Greedy Patterns in LeetCode](#common-greedy-patterns-in-leetcode)
  - [Greedy vs. Dynamic Programming](#greedy-vs-dynamic-programming)
  - [Problems That Use This Pattern](#problems-that-use-this-pattern)
<!--toc:end-->

## The Basic Idea

A greedy algorithm builds a solution **one step at a time**, always making the choice that looks best *right now* — without reconsidering past decisions or looking ahead.

It's the opposite of brute force (which tries everything) and dynamic programming (which carefully tracks overlapping subproblems). Greedy is simpler and faster, but it only works when the "locally best" choice always leads to the "globally best" answer.

---

## Beginner Explanation

Imagine you're collecting coins scattered on the floor and you can only pick up one at a time. A greedy strategy says: always reach for the biggest coin nearest to you.

That works great for collecting coins. But greedy doesn't always work — for example, if you had to choose a path through a maze, always picking the shortest immediate step might lead you into a dead end. That's when you'd need dynamic programming instead.

Greedy works when the problem has a property called **optimal substructure** + **greedy choice property** — which basically means "making the locally best choice at each step doesn't ruin the overall answer."

---

## How to Recognize a Greedy Problem

Look for these signals in the problem statement:

- "maximize the **number** of..." or "minimize the **number** of..."
- You need to select or schedule items with a limited resource (budget, time, capacity)
- Items can be considered independently — choosing one doesn't complicate other choices
- The problem says "you can process items in any order" (a hint that sorting helps)

---

## The Two Properties That Make Greedy Safe

**1. Greedy Choice Property** — A globally optimal solution can be reached by making locally optimal choices. In other words, the greedy pick at each step is never "wrong."

**2. Optimal Substructure** — After making a greedy choice, the remaining problem has the same structure as the original. You can keep applying the same logic recursively.

If both hold, greedy works. If subproblems *interact* (choosing one affects what's possible later), you likely need DP instead.

---

## High-Level Pseudocode (Generic Greedy)

```
sort or order candidates by some criterion (cheapest, shortest, earliest, etc.)

result = empty
for each candidate in order:
    if candidate fits within remaining resource:
        pick it
        update remaining resource

return result
```

The tricky part is always: **what criterion do you sort by?** That depends on the problem.

---

## Common Greedy Patterns in LeetCode

| Goal | Sort by |
|---|---|
| Maximize number of items bought | cost ascending |
| Maximize number of meetings scheduled | end time ascending |
| Minimize cost to connect all nodes | edge weight ascending (Kruskal's) |
| Maximize profit with one transaction | track running min price |

---

## Greedy vs. Dynamic Programming

| | Greedy | Dynamic Programming |
|---|---|---|
| Speed | Fast — O(n log n) or better | Slower — often O(n²) or O(n·k) |
| When it works | Greedy choice property holds | Overlapping subproblems exist |
| Looks ahead? | No — commits immediately | Yes — considers all sub-cases |
| Easier to implement? | Usually yes | Usually no |

When in doubt, try greedy first. If you can construct a counterexample where the greedy pick leads to a wrong answer, switch to DP.

---

## Problems That Use This Pattern

- [1833. Maximum Ice Cream Bars](./notes.md) — sort by price ascending, buy cheapest first
