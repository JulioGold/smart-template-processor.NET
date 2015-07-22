# smart-template-processor.NET
You can process an template with an context object. 
  
## Usage  

```
Install-Package SmartTemplateProcessor 
```

### Simple example  

```C#
    string template = "Hello {{nome}}! How are you {{nome}}? Your e-mail address is: {{email.address}}?";

    object obj = new
    {
        nome = "JulioGold",
        email = new
        {
            address = "julio.gold@gmail.com"
        }
    };

    Console.WriteLine(Processor.ProcessTemplate(template, obj));
```  

### We really can go more deep and complex 

```C#
    string template2 = "Hello {{company.nome}}! How are you {{company.nome}}? This is your {{company.email.type}} e-mail address {{company.email.address}}?";

    object obj2 = new
    {
        company = new
        {
            nome = "JulioGold",
            email = new
            {
                address = "julio.gold@gmail.com",
                type = "Comercial"
            }
        }
    };

    Console.WriteLine(Processor.ProcessTemplate(template2, obj2));
```  

Thanks  