import React, { Component } from "react";
import { Table } from "react-bootstrap";

export class StudentStatistics extends Component {
  constructor(props) {
    super(props);
    this.state = { statistics: [] };
  }

  refreshList() {
    fetch("https://localhost:44368/api/Student/Statistics", { mode: "cors" })
      .then((response) => response.json())
      .then((data) => {
        this.setState({
          statistics: data,
        });
      });
  }

  componentDidMount() {
    this.refreshList();
  }

  componentDidUpdate() {
    this.refreshList();
  }

  render() {
    const { statistics: statistics } = this.state;
    return (
      <div>
        <Table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Average</th>
              <th>Number of ones</th>
              <th>Best grade</th>
            </tr>
          </thead>
          <tbody>
            {statistics.map((statistics) => (
              <tr key={statistics.studentId}>
                <td>{statistics.name}</td>
                <td>{statistics.average}</td>
                <td>{statistics.numberOfOnes}</td>
                <td>{statistics.bestGrade}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    );
  }
}
