import React, { Component } from "react";
import { Table, Button, ButtonToolbar } from "react-bootstrap";
import { AddStudent } from "../components/AddStudent";
import { AddGrade } from "../components/AddGrade";

export class AllStudent extends Component {
  constructor(props) {
    super(props);
    this.state = { students: [], addStudentShow: false, addGradeShow: false };
  }

  refreshList() {
    fetch("https://localhost:44368/api/Student/GetAllStudents", { mode: "cors" })
      .then((response) => response.json())
      .then((data) => {
        this.setState({
          students: data,
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
    const { students } = this.state;
    let addStudentClose = () => this.setState({ addStudentShow: false });
    let addGradeClose = () => this.setState({ addGradeShow: false });
    return (
      <div>
        <Table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Year</th>
              <th>Birtdate</th>
              <th>Phonenumber</th>
              <th>Add grade</th>
            </tr>
          </thead>
          <tbody>
            {students.map((stud) => (
              <tr key={stud.id}>
                <td>{stud.name}</td>
                <td>{stud.year}</td>
                <td>{stud.dateOfBirth}</td>
                <td>{stud.phoneNumber}</td>
                <td>
                  <ButtonToolbar>
                    <Button variant="primary" onClick={() => this.setState({ addGradeShow: true })}>
                      Add grade
                    </Button>
                    <AddGrade studentId={stud.id} show={this.state.addGradeShow} onHide={addGradeClose} />
                  </ButtonToolbar>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
        <ButtonToolbar>
          <Button variant="primary" onClick={() => this.setState({ addStudentShow: true })}>
            Add Student
          </Button>
          <AddStudent show={this.state.addStudentShow} onHide={addStudentClose} />
        </ButtonToolbar>
      </div>
    );
  }
}
