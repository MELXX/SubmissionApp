import 'package:flutter/material.dart';
import 'package:flutter_application_1/Config/DefaultVars.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class UserListWidget extends StatefulWidget {
  @override
  _UserListWidgetState createState() => _UserListWidgetState();
}

class _UserListWidgetState extends State<UserListWidget> {
  List<Map<String, dynamic>> _users = [];

  @override
  void initState() {
    super.initState();
    _fetchUsers();
  }

  Future<void> _fetchUsers() async {
    final response = await http.get(Uri.parse(DefaultVars.baseurl+'/Users/list'));

    if (response.statusCode == 200) {
      final List<dynamic> usersJson = jsonDecode(response.body);
      setState(() {
        _users = usersJson.map((user) => Map<String, dynamic>.from(user)).toList();
      });
    } else {
      throw Exception('Failed to load users');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('User List'),
      ),
      body: _users.isEmpty
          ? const Center(
              child: CircularProgressIndicator(),
            )
          : SingleChildScrollView(
              scrollDirection: Axis.vertical,
              child:Container(
                decoration: BoxDecoration(
                  border: Border.all(color: Colors.white), // Add border to the container
                ),
                child: DataTable(
                  dataTextStyle: DefaultVars.optionStyle,
                headingTextStyle: DefaultVars.optionStyle,
                  columns: [
                    DataColumn(label: Text('Name')),
                    DataColumn(label: Text('Surname')),
                    DataColumn(label: Text('Email')),
                  ],
                  rows: _users.map((user) {
                    return DataRow(cells: [
                      DataCell(Text(user['name'])),
                      DataCell(Text(user['surname'])),
                      DataCell(Text(user['email'])),
                    ]);
                  }).toList(),
                ),
              ),
          ),
            
            
    );
  }
}

// void main() {
//   runApp(MaterialApp(
//     home: UserListWidget(),
//   ));
//}
