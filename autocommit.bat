:loop
git add --all
git commit -m "AI_SAC: Automatical commit (Date: %time%)"
git push
timeout /t 10
goto loop