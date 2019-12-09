def exit():
    first.destroy()
def sign():
    def sign_Up():
        db.execute("create table if not exists us(email text,pass text)")
        db.execute("insert into us(email,pass) values(?,?)", (entry_1.get(), entry_2.get()))
        db.commit()
        signup.destroy()

    signup = Tk()
    lb=StringVar()
    signup.geometry('500x500')
    signup.title("Welcom to time out")
    signup.config(bg="#bff5ba")
    label_0 = Label(signup, text="SIGN-UP",width=20,font=("bold", 20),bg="#bff5ba")
    label_0.place(x=90,y=50)

    label_1 = Label(signup, text="Email",width=20,font=("bold", 10),bg="#bff5ba")
    label_1.place(x=80,y=130)
    entry_1 = Entry(signup)
    entry_1.place(x=240,y=130)


    label_2 = Label(signup, text="password",width=20,font=("bold", 10),bg="#bff5ba")
    label_2.place(x=68,y=180)
    entry_2 = Entry(signup)
    entry_2.place(x=240,y=180)
    label_3 = Label(signup, text="Gender",width=20,font=("bold", 10),bg="#bff5ba")
    label_3.place(x=70,y=230)
    var = IntVar()
    Radiobutton(signup, text="Male",padx = 5, variable=var, value=1,bg="#bff5ba").place(x=235,y=230)
    Radiobutton(signup, text="Female",padx = 20, variable=var, value=2,bg="#bff5ba").place(x=290,y=230)

    label_4 = Label(signup, text="AGE",width=20,font=("#fca103", 10),bg="#bff5ba")
    label_4.place(x=70,y=280)

    list1 = ['17','18','19','20','21','22','23','24','25','26'];
    c=StringVar()
    droplist=OptionMenu(signup,c, *list1)
    droplist.config(width=15)
    c.set('select your age')
    droplist.place(x=240,y=280)
    label_4 = Label(signup, text="Accept",width=20,font=("bold", 10),bg="#bff5ba")
    label_4.place(x=85,y=330)
    var1 = IntVar()
    Checkbutton(signup, text="YES", variable=var1,bg="#bff5ba").place(x=235,y=330)
    txt=Text(signup,width=10,bg='brown',fg='green')
    Button(signup, text='SIGN-UP',width=20,bg='brown',fg='white',command=sign_Up).place(x=180,y=380)
    signup.mainloop()


def log():
    def login():
        v=1
        vx=0
        cusror = db.execute("select*from us")
        for row in cusror:
          if(row["email"]!=entry_1.get()  or row["pass"]!=entry_2.get()):
            v=v+1
          else:
              vx=1
        if(vx==1):
            db.commit()
            db.close()
            first.destroy()
            gaming()
            log.destroy()
        else:label_10 = Label(log, text=" not fount in the system or password is wrong", width=70, font=("bold", 10), bg="#bff5ba").place(x=100, y=100)
    log=Tk()
    log.geometry('500x500')
    log.title("LOG-IN")
    log.config(bg="#bff5ba")
    label_0 = Label(log, text="LOG-IN", width=20, font=("bold", 20), bg="#bff5ba")
    label_0.place(x=90, y=50)
    z2 = Label(log, text="Email", width=20, font=("bold", 10), bg="#bff5ba")
    z2.place(x=80, y=130)
    entry_1 = Entry(log)
    entry_1.place(x=240, y=130)
    z3 = Label(log, text="password", width=20, font=("bold", 10), bg="#bff5ba")
    z3.place(x=68, y=180)
    entry_2 = Entry(log,show='*')
    entry_2.place(x=240, y=180)
    Button(log, text='LOG-IN',width=30,bg='brown',fg='white',command=login).place(x=150,y=250)
def gaming():
    log=Tk()
    log.geometry('500x500')
    log.title("WELCOM BACK")
    log.config(bg="#bff5ba")
    label_0 = Label(log, text="HI AGIN", width=20, font=("bold", 20), bg="#bff5ba")
    label_0.place(x=90, y=50)

first=Tk()
first.geometry('500x500')
first.title("Welcom to time out")
first.config(bg="#bff5ba")

label_0 = Label(first, text="WELCOME TO TIME OUT",width=20,font=("bold", 20),bg="#bff5ba")
label_0.place(x=90,y=50)
