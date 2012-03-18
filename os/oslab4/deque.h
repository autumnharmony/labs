#ifndef DEQUE_H_INCLUDED
#define DEQUE_H_INCLUDED
#include <stdlib.h>
#include <cstdio>
#include <cstring>

typedef struct {
    double* a;

    double* start;
    double* end;
    unsigned count;
    double* front;
    double* back;




} deque;



void deque_print(deque*);
void deque_print_all(deque* d);
bool deque_isEmpty(deque*);
void deque_push_front(deque*, double);
double deque_pop_front(deque*);

void deque_push_back(deque*, double);
double deque_pop_back(deque*);

void deque_init(deque*, int);

#endif // DEQUE_H_INCLUDED
