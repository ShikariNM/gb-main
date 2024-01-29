%Rules
sum([], 0).
sum([H|T], Sum) :-
    sum(T, Sum1), Sum is Sum1 + H.
