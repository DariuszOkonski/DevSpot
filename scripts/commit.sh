#!/usr/bin/env bash

if ! git rev-parse --git-dir > /dev/null 2>&1; then
  echo "Not a git repository. Run this from a repo root or initialize git first." >&2
  exit 1
fi

echo "Staging all changes..."
git add -A

if [ -z "$1" ]; then
  echo "No commit message provided. Launching default editor for commit message..."
  git commit
else
  echo "Committing with message: $1"
  git commit -m "$1"
fi
