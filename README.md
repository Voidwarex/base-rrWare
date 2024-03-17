# base-rrWare
Powered solely by MySQL queries. It's a unique educational demonstration that highlights the potential risks of database vulnerabilities.

If you're new to MySQL and C# code, this might be a bit over your head. Here's the deal: this program acts as the 'zombie,' running on the client's machine. You can tweak the database values either through another program or directly in phpMyAdmin. Then, the 'cdc' method checks these values against the cc_Tick setting (usually set to 5000 milliseconds or 5 seconds) and executes whatever action you've instructed it to.

                    switch (command.ToLower())
                    {
                        case "clear":
                            break;
                        case "beep":
                            Console.Beep(500, 500);
                            break;
                        case "message":
                            MessageBox.Show("Hello, world!", "Message");
                            break;
                        default:
                            Console.WriteLine("Unknown command: " + command);
                            break;
                    }

As you see, if the database value returns with 'beep' it will play a beep through the clients machine. Change it to how ever you want it :)
