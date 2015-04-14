package transport

import (
	"fmt"
	"io"
	"bufio"
	"strings"
	"strconv"
	"container/list"
)

func LoadInput(r io.Reader) {

	scanner := bufio.NewScanner(r)

	scanner.Split(bufio.ScanLines)

	routes := list.New()
	weights := list.New()

	if scanner.Scan() {
		numOfLines, err := strconv.Atoi(scanner.Text())

		if err != nil {

			for i := 0; i < numOfLines; i++ {

				if scanner.Scan() {
					line := scanner.Text()
					stops := list.New()
					arr := strings.Split(line, " ")
					for _, elem := range arr {
						x, _ := strconv.Atoi(elem)
						stops.PushBack( x )
					}
					routes.PushBack(stops)
				}
			}

			for scanner.Scan() {
				line := scanner.Text()
				we := list.New()
				for _, elem := range strings.Split(line, " ") {
					x, _ := strconv.Atoi(elem)
					weights.PushBack( x )
				}
				weights.PushBack( we )
			}
		}

		fmt.Printf("%q\n", routes)
		fmt.Printf("%q\n", weights)
	}
}
