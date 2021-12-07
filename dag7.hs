main = putStrLn ("The answer is " ++ answer ++ " the second answer is " ++ answer2)
answer = show (lowestdiff (allposdiff input))
testinput = [16,1,2,0,4,2,7,1,2,14]
testinput2 = [16,12]
answer2 = show("test")

absDiff :: Num a => a -> a -> a
absDiff n = abs . (n-)

--neemt een lijst getallen x en een getal y en geeft een lijst met voor elk getal in x de afstand tot y
diffInput x y = map (absDiff y) x

--neemt een lijst getallen x en een getal y en geeft een getal met de som van alle afstanden in x tot y
totaldiff x y = sum (diffInput x y)

--neemt een lijst getallen x en geeft een lijst met voor elk waarde in x de afstand van alle andere getallen tot dat getal
allposdiff :: [Int] -> [Int]
allposdiff x
    | x == []   = []
    | otherwise = map ((totaldiff) input) x

lowestdiff [] = 1000000
lowestdiff [x] = x
lowestdiff (x:xs) = min (min x (head xs)) (lowestdiff xs)

fuelusage 0 = 0
fuelusage 1 = 1
fuelusage x = (x + fuelusage (x-1))

nodevalues x = map (fuelusage . (absDiff x)) input

alloptions = map nodevalues [100..1000]

optionvalue = map (sum) alloptions

bestoption = lowestdiff optionvalue
