ljmp start
org 30h
  ; Min or Max of array:
  ;   R2:R0 - Adress of array
  ;   R4    - Length
  ;   20h.0 - min - 1, max - 0
  ; Uses:
  ;   R5:R7
  minmaxArr:
    push acc                   ; push variables
    push psw
    push p2
    push 70h
    push DPL
    push DPH
    
    mov a, r4                 ; if length == 0
    jz   return
    mov r7,a
    
    mov dpl, r0
    mov dph, r2
    
    jb 20h.0, min
    max:
	    mov 70h,#00h ; current min/max
	    mov 71h,#00h
	   jmp @p 
    min:
	    mov 70h,#0FFh
	    mov 71h,#0FFh
    	
    @p:	
    ;mov a, @r0
    mov p2, r2
    cycle:
        movx a, @DPTR
    	cjne a,70h, @cmpHi
    	jmp @cmpLow
    	
    	@cmpHi:
    	
    	maybeMinMax:
    	
    		jb 20h.0,fm
    		orl c,20h.0
    		jnc newMinMax
    		jmp next
    		fm:
    		anl c,20h.0
    		jc newMinMax
    	
    	jmp next
    	newMinMax:
    		mov 70h, a
			inc DPTR
    		movx a, @DPTR
    		mov 71h,a
			jmp next1
    	@cmpLow:
    		inc DPTR
    		movx a, @DPTR
    		cjne a,71h, notequal
    		jmp next1
    		
    		notequal:
    		jb 20h.0,fm2
    		orl c,20h.0
     		jnc new2MinMax
    		jmp next1
    		fm2:
    		anl c,20h.0
    		jc new2MinMax
    		jmp next1
    		new2MinMax:
    		mov 71h, a
    		;movx a, @DPTR
    		dec DPL
    		
    		movx a, @DPTR
    		mov 70h,a
    		inc DPTR
    		inc DPTR
    		jmp next0
    	
    		equal:
    		jmp next1
    	
    	next:
    	inc DPTR
    	next1:
		inc DPTR
    	next0:    
    djnz r7,cycle 
    
    
  cmp:  
    

  return:                      ; return from procedure
  	mov r5, 70h
  	mov r7, 71h
    pop DPH ; pop vars
    pop DPL
    pop  70h                   
    pop  p2
    pop  psw
    cjne a, #00h, setErr
    clr  f0
  retAcc:
    pop  acc
    ret

  setErr:                      ; set F0 if error
    setb f0
    sjmp retAcc
  
  errCode:
    mov  a, #01h
    sjmp return
  

  ; Program  
  start:
    mov sp, #2Fh
    
    mov r2, #00h               ; start segment
    mov r0, #50h               ; start address

    mov r4, #06h               ; length
    
    acall minmaxArr
end