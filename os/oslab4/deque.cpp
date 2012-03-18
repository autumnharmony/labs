#include "deque.h"

bool deque_isEmpty(deque* d){
 return false;
}

void enlarge(deque* d){
        int n = (d->end - d->start); // количество ячеек
        printf("enlarge %d \n",n);

        //unsigned frontshift = d->front - d->start;
        //unsigned backshift = d->back - d->start;

        double* start = d->start;
        double* end= d->end;
        double* back = d->back;
        double* front = d->front;

        //printf("start %x ",start);

        d->start = (double*) realloc(d->start, 2*n*sizeof(double));

        //printf("start %x \n",d->start);

        //printf("end %x ",end);
        d->end=d->start + 2*n;

        //printf("end %x \n",d->end);
        //printf("front %x back %x",front, back);
        d->front = d->start + (front - start);
        d->back = d->start + (back - start);
        //printf(" front %x back %x \n",d->front, d->back);

//free(oldstart);
//iiiiiiiiiiii

        //d->front = d->end -
        //printf("new %d \n",d->end - d->start);
        //deque_print_all(d);


        //printf("memove");
        d->back = (double*)memmove(d->back+n, d->back, (d->count+1)*sizeof(double));
        d->front+=n;
        //deque_print_all(d);

}


void deque_push_front(deque* d, double e){
    if (d->front == d->end){
        //printf("realloc");
        enlarge(d);
    }


        *(d->front) = e;
        d->front++;
        d->count++;

}
double deque_pop_front(deque* d){
    d->front--;
    d->count--;
    return *(d->front+1);
}


void deque_push_back(deque* d, double e){
    if (d->back == d->start) {
        //printf("realloc");
        enlarge(d);
    }

        *(d->back) = e;
        d->back--;
        d->count++;

}
double deque_pop_back(deque* d){
    d->back++;
    d->count--;
    return *(d->back-1);
}

void deque_init(deque* d,int n){
    d->a = (double*)calloc(n,sizeof(double));
    d->start= d->a;
    d->end = d->a + n;
    d->front = d->a + n/2;
    d->back = d->a + n/2 -1;
    d->count = 0;
}

void deque_print(deque* d){


    double* current = d->back+1;

    while (current!= d->front){
        printf("%lf ", *(current));
        current++;
    }
    printf("\n");

}

void deque_print_all(deque* d){

    printf("%x %x %x %x \n", d->start,d->back, d->front, d->end);
    //printf(" *(d->back) = %lf addr:%x\n", *(d->back), d->back);

    double* current = d->start;

    while (current!= d->end){
        printf("%lf ", *(current));
        current++;
    }
    printf("\n");

}

