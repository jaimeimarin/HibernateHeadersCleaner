# HibernateHeadersCleaner
A simple C# console program to clean the autogenerated headers in a Hibernate Java project

## Run
You can run it with or without arguments

    HibernateHeadersCleaner.exe "extension" "text_to_clean" 


## Arguments
    "extension"
  
  Indicates the extension to evaluate the files. 
  Default value: ".java"
                
    "text_to_clean"

  Indicates the text of the init of the line in order to delete it.
  Default value: "// Generated"

