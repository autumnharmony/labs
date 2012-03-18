.include "C:\VMLAB\include\m8535def.inc"

rjmp start
.org $30
  ; Min || Max of 2-byte array:
  ;   R20 : R19 - Source Address
  ;   R18 - Length
  ;   R17 : R16 - result (min || max)
  ;   R13 min 1 or max 0;
  ; Return:
  ;   if ERROR then to R18 set 1
  ; Uses:
  ;   Stack - 9 bytes for call
  ;   R
 minmaxArr:
    push r6
    in r6, sreg
    push r6

    push r15
    ;push r16
    ;push r17

    push r27                   ; push X
    push r26
    push r29                   ; push Y
    push r28

    mov  xh, r20
    mov  xl, r19

    ldi  r20, 0                ; simple constant 0
    ldi  r16, low(ramend)

    cpi  r18, 0                ; if length == 0
    brne notequal0len
    rjmp setErr
  notequal0len:
  bst r13,0
  tst r13
  breq fmax
  fmin:
   ldi r17,0xFF
   ldi r16,0xFF
   rjmp find
  fmax:
	ldi r17,0x00
	ldi r16,0x00

  find:
  	cmpHi:
    ld r15,x+
    ld r14,x+
    cp r15,r17
    breq cmpLo
    brtc t0
 	 t1:
	  brlo newminmax
	  rjmp next
	 t0:
	  brge newminmax
	  rjmp next

   cmpLo:
    ;ld r15,x+
    ;ld r14,x+
    cp r14, r16
    breq next
    brtc tt0
 	 tt1:
	  brlo newminmax
	  rjmp next
	 tt0:
	  brge newminmax
	  rjmp next

	newminmax:
	 ; новый min/max
	 mov r16, r14
	 mov r17, r15
	
	
	


   next:

   dec r18
   breq return
  rjmp find

  setErr:
    ldi  r18, 1                ; set error

  return:
    pop  r6
    out  sreg, r6
    pop  r6

    ;pop  r17
    ;pop  r16
    pop  r15

    pop  r27
    pop  r26
    pop  r29
    pop  r28
    ret

  start:
    ldi  r16, high(ramend)
    out  sph, r16
    ldi  r16, low(ramend)
    out  spl, r16

	 ldi  r16, 1 ; max
    mov r13, r16

    ldi  r20, 0x00             ; start segment
    ldi  r19, 0x60             ; start address
    ;ldi  r22, 0                ; destination segment
    ;ldi  r21, 0xA0             ; destination address
    ldi  r18, 6                ; length

    rcall minmaxArr

  forever:
    nop                        ; Infinite loop.
    rjmp forever


