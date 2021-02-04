Q: If we are going to deploy this on production, what do you think the next improvement
that you will prioritize next? This can be a feature, a tech debt, or an architectural
design.

A: 
This will be my priorities
>Proper data / database - Different employee salary, work days, holidays, other deductions and etc. [High]
>Proper / More Error handling - Add more unit tests, Error logging and error handling [High]
>UI/UX - As of now it has very simple design. UI/UX defenitely needs improvement [Medium]
>Architecture - When everything is opeartional, I'd say we can split the back and and front end into 2 different projects. 
API and Client we can use more lightweight libraries for the front end improving the UI/UX. This could be in the version 2 though. [Medium]

Some notes:
>Used cache for storing employees.
>Getting all the weekdays as workday. not fixed 22