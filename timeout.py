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
