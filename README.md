# Machine Learning CLI
This is a CLI where I implement my own machine learning algorithms and where they can easily be tested on many different data sets.

## List of Ideas
- Start page with list of (data sets, algorithms, wiki pages etc.) divided into categories (new, last visited) and also show the last runs/tranings on this start page.
- A CLI similar to the kubectl-cli, you have to learn it, but it is fast for doing anything once learned.
- When starting new run a lot of tasks are listed, for example: 1.0 Choose algorithm, 1.1 Choose algorithm variant, 2.0 Choose data set, 2.1 Apply pre-processing? 
- When all tasks are fulfilled a new run can begin.
- Store various stats and all previous runs.
- Progress bars for long tasks.
- Wiki pages for everything, this is to help me learn also.
- Comparison of my algorithms with ML.NET.
- Support different versions of the same algorithm.
- Algorithm variants: K-Means and Parallel K-Means for example.
- Data set and algorithm tags. Used to make sure only applicable data sets are selectable when running an algorithm.
- Run only with a subset of the data and evaluate the results with the remaining data.
- Support more scores, not just total correct predictions.
- Save models (outputs of trainings) for later.
- Allow for easily swapping tie-breaking techniques in KNN-algorithm. Make it reusable for other algorithms. 
- Allow for more data preprocessing, like normalization.

## Features Required for Others to be Able to Use this App
- Uploading of custom data sets.
- Creation of custom algorithms.

## TODO
- Parameter for changing trainingSetFactor in run command.
- Persist Statistics on computer but do not version control them.