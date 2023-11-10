using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstWindowsFormApp
{
    internal class ShuntingAlgorithm
    {
        public string[] Parse(string input)
        {
            Regex doubleRegex = new Regex(@"-?\d+(?:\.\d+)?");
            Regex charRegex = new Regex(@"[\^|+|\-|*|\/]");
            var inputString = input.Split(' ').ToList();
            var queue = new Queue<string>();
            var stack = new Stack<string>();
            //dictionary used to compare order of operations
            Dictionary<string, int> operations = new Dictionary<string, int>()
            {
                ["^"] = 4,
                ["*"] = 3,
                ["/"] = 3,
                ["+"] = 2,
                ["-"] = 2,
                ["("] = 1,
                [")"] = 1
            };

            
            // regular expressions used for determining if an input is a double or character/operation


            for (int i = 0; i < inputString.Count; i++)
            {
                if (inputString[i] == "(")
                {
                    stack.Push(inputString[i]);
                }
                //if closed brackets, then pops everything off the stack until open brackets reached
                else if (inputString[i] == ")")
                {
                    while (stack.Count > 0)
                    {
                        if (stack.Peek() == "(")
                        {
                            stack.Pop();
                            break;
                        }
                        queue.Enqueue(stack.Pop());
                    }
                }
                //if double, then put on queue
                else if (doubleRegex.IsMatch(inputString[i]))
                {
                    queue.Enqueue(inputString[i]);
                }
                //if character, then checks stack and pops from stack if head has higher precedence
                else if (charRegex.IsMatch(inputString[i]))
                {
                    if (stack.Count > 0)
                    {
                        var topPrecedence = operations[stack.Peek()];
                        var currentPrecedence = operations[inputString[i]];
                        while (stack.Count > 0 && (topPrecedence >= currentPrecedence))
                        {
                            queue.Enqueue(stack.Pop());

                        }
                    }
                    stack.Push(inputString[i]);
                }
            }
            //at the end, pops everything off the stack and places onto queue
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                queue.Enqueue(top);
            }
            return queue.ToArray();
        }

        public string Evaluate(string[] queueArray)
        {
            var stack = new Stack<string>();    
            Regex doubleRegex = new Regex(@"-?\d+(?:\.\d+)?");
            Regex charRegex = new Regex(@"[\^|+|\-|*|\/]");

            for (int i = 0; i < queueArray.Length; i++)
            {
                if (doubleRegex.IsMatch(queueArray[i]))
                {
                    stack.Push(queueArray[i]);
                }
                else if (charRegex.IsMatch(queueArray[i]))
                {
                    var rightNumberString = stack.Pop();
                    double rightNumber = Double.Parse(rightNumberString);
                    var leftNumberString = stack.Pop();
                    double leftNumber = Double.Parse(leftNumberString);
                    char charOperation = Char.Parse(queueArray[i]);
                    /*double value = charOperation switch
                    {
                        '^' => Math.Pow(leftNumber, rightNumber),
                        '*' => leftNumber * rightNumber,
                        '/' => rightNumber == 0 ? throw new Exception("Cannot divide by 0") : leftNumber / rightNumber,
                        '+' => leftNumber + rightNumber,
                        '-' => leftNumber - rightNumber,
                        _ => throw new NotImplementedException()
                    };*/
                    double value = 0;
                    switch (charOperation)
                    {
                        case '^':
                            value = Math.Pow(leftNumber, rightNumber);
                            break;
                        case '/':
                            value = leftNumber / rightNumber;
                            break;
                        case '*':
                            value = leftNumber * rightNumber;
                            break;
                        case '+':
                            value = leftNumber + rightNumber;
                            break;
                        case '-':
                            value = leftNumber - rightNumber;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    var valueString = value.ToString();
                    stack.Push(valueString);
                }
            }
            return stack.Pop();
        }
    }
}
