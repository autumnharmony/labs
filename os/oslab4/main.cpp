#include <iostream>
#include "deque.h"
using namespace std;

int main()
{
    cout << "Hello world!" << endl;

    deque d;
    deque_init(&d, 4);
    deque_push_front(&d,10);
    deque_print(&d);
    deque_push_back(&d,1);
    deque_print(&d);
    deque_push_back(&d,2);
    deque_print(&d);
    deque_push_back(&d,3);
    deque_print(&d);
    deque_push_back(&d,4);
    deque_print(&d);
    deque_push_front(&d,5);
    deque_print(&d);

    deque_push_front(&d,6);
    deque_print(&d);

    deque_push_front(&d,7);
    deque_print(&d);

    deque_push_front(&d,8);
    deque_print(&d);

    deque_push_front(&d,9);
    deque_print(&d);


    deque_print(&d);



    return 0;
}
